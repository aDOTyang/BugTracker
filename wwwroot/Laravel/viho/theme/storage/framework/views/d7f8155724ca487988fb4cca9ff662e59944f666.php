<?php $__env->startSection('title'); ?>Sparkline Chart
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Sparkline Chart</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Charts</li>
		<li class="breadcrumb-item active">Sparkline Chart</li>
	<?php echo $__env->renderComponent(); ?>
	
	<div class="container-fluid">
		<div class="row">
			<div class="col-lg-4 col-md-6 col-sm-12 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Mouse Speed Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="mouse-speed-chart-sparkline"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-4 col-md-6 col-sm-12 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Simple Bar Charts</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="custom-line-chart"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-4 col-md-6 col-sm-12 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Line Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder line-chart-sparkline" id="line-chart-sparkline"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-4 col-md-6 col-sm-12 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Simple Line Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="simple-line-chart-sparkline"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-4 col-md-6 col-sm-12 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Bar Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="bar-chart-sparkline"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-4 col-md-6 col-sm-12 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Pie chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="pie-sparkline-chart"></div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>	
	
	<?php $__env->startPush('scripts'); ?>
	<script src="<?php echo e(asset('assets/js/chart/sparkline/sparkline.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/sparkline/sparkline-script.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/charts/chart-sparkline.blade.php ENDPATH**/ ?>