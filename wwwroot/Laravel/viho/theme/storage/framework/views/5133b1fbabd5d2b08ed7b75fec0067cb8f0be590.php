<?php $__env->startSection('title'); ?>Chartist Chart
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<link rel="stylesheet" type="text/css" href="<?php echo e(asset('assets/css/chartist.css')); ?>">
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Chartist Chart</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Charts</li>
		<li class="breadcrumb-item active">Chartist Chart</li>
	<?php echo $__env->renderComponent(); ?>
	
	<div class="container-fluid">
		<div class="row">
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Advanced SMIL Animations</h5>
					</div>
					<div class="card-body">
						<div class="ct-6 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>SVG Path animation</h5>
					</div>
					<div class="card-body">
						<div class="ct-7 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Animating a Donut with Svg.animate</h5>
					</div>
					<div class="card-body">
						<div class="ct-8 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Bi-polar Line chart with area only</h5>
					</div>
					<div class="card-body">
						<div class="ct-5 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Line chart with area</h5>
					</div>
					<div class="card-body">
						<div class="ct-4 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Bi-polar bar chart</h5>
					</div>
					<div class="card-body">
						<div class="ct-9 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Stacked bar chart</h5>
					</div>
					<div class="card-body">
						<div class="ct-10 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Horizontal bar chart</h5>
					</div>
					<div class="card-body">
						<div class="ct-11 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Extreme responsive configuration</h5>
					</div>
					<div class="card-body">
						<div class="ct-12 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Simple line chart</h5>
					</div>
					<div class="card-body">
						<div class="ct-1 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Holes in data</h5>
					</div>
					<div class="card-body">
						<div class="ct-2 flot-chart-container"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Filled holes in data</h5>
					</div>
					<div class="card-body">
						<div class="ct-3 flot-chart-container"></div>
					</div>
				</div>
			</div>
		</div>
	</div>	
	
	<?php $__env->startPush('scripts'); ?>
	<script src="<?php echo e(asset('assets/js/chart/chartist/chartist.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/chartist/chartist-plugin-tooltip.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/chartist/chartist-custom.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/charts/chartist.blade.php ENDPATH**/ ?>