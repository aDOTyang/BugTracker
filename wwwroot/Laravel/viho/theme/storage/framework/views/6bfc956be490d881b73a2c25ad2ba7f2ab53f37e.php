<?php $__env->startSection('title'); ?>Popover
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
		<h3>Popover</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Base</li>
		<li class="breadcrumb-item active">Popover</li>
	<?php echo $__env->renderComponent(); ?>
   
<div class="container-fluid">
	<div class="row popover-main">
		<div class="col-sm-12">
			<div class="card">
				<div class="card-header pb-0">
					<h5>Basic Examples</h5>
					<span>lorem ipsum dolor sit amet, consectetur adipisicing elit</span>
				</div>
				<div class="card-body btn-showcase">
					<button class="btn btn-primary example-popover" type="button" data-bs-toggle="popover" title="Popover title" data-bs-content="And here's some amazing content. It's very engaging. Right?">Click to toggle popover</button><a class="example-popover btn btn-primary" tabindex="0" role="button" data-bs-toggle="popover" data-bs-trigger="focus" title="Popover title" data-bs-content="And here's some amazing content. It's very engaging. Right?">Dismissible popover</a>
					<button class="example-popover btn btn-primary" type="button" data-bs-trigger="hover" data-container="body" data-bs-toggle="popover" data-bs-placement="bottom" title="Popover title" data-offset="-20px -20px" data-bs-content="Vivamus sagittis lacus vel augue laoreet rutrum faucibus.">On Hover Tooltip</button>
				</div>
			</div>
		</div>
		<div class="col-sm-12">
			<div class="card">
				<div class="card-header pb-0">
					<h5>Direction</h5>
					<span>lorem ipsum dolor sit amet, consectetur adipisicing elit</span>
				</div>
				<div class="card-body btn-showcase">
					<button class="example-popover btn btn-primary" type="button" data-container="body" data-bs-toggle="popover" data-bs-placement="top" title="Popover title" data-bs-content="Vivamus sagittis lacus vel augue laoreet rutrum faucibus.">Popover on top</button>
					<button class="example-popover btn btn-primary" type="button" data-container="body" data-bs-toggle="popover" data-bs-placement="right" data-bs-content="Vivamus sagittis lacus vel augue laoreet rutrum faucibus.">Popover on right</button>
					<button class="example-popover btn btn-primary" type="button" data-container="body" data-bs-toggle="popover" data-bs-placement="bottom" data-bs-content="Vivamus sagittis lacus vel augue laoreet rutrum faucibus.">Popover on bottom</button>
					<button class="example-popover btn btn-primary" type="button" data-container="body" data-bs-toggle="popover" data-bs-placement="left" data-bs-content="Vivamus sagittis lacus vel augue laoreet rutrum faucibus.">Popover on left</button>
				</div>
			</div>
		</div>
	</div>
</div>
	<?php $__env->startPush('scripts'); ?> 
		<script src="<?php echo e(asset('assets/js/counter/jquery.waypoints.min.js')); ?>"></script>
		<script src="<?php echo e(asset('assets/js/counter/jquery.counterup.min.js')); ?>"></script>
		<script src="<?php echo e(asset('assets/js/counter/counter-custom.js')); ?>"></script>
		<script src="<?php echo e(asset('assets/js/popover-custom.js')); ?>"></script>
	<?php $__env->stopPush(); ?>
<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/ui-kits/popover.blade.php ENDPATH**/ ?>